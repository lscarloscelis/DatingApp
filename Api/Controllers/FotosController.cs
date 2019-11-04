using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Api.DTOs.Fotos;
using Api.Helpers;
using Api.Models;
using Api.Repos.Fotos;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/{usuarioDocument}/fotos")]
    public class FotosController : ControllerBase
    {
        private readonly IOptions<CloudinaryCreds> cloudinary;
        private readonly IFotosRepo fotosRepo;
        private Cloudinary myCloudinary;
        public FotosController(IOptions<CloudinaryCreds> cloudinary, IFotosRepo fotosRepo)
        {
            this.fotosRepo = fotosRepo;
            this.cloudinary = cloudinary;
            Account cloduAccount = new Account(cloudinary.Value.Name,
                cloudinary.Value.Key, cloudinary.Value.Secret);
            myCloudinary = new Cloudinary(cloduAccount);
        }

        [HttpGet("{id}")]
        public IActionResult GetFotos(string id)
        {
            var usrDb = fotosRepo.GetUsuario(id);
            var userFotos = fotosRepo.GetFotoByUser(usrDb);
            List<FotoParaVista> listaFotos = new List<FotoParaVista>();
            foreach (var foto in userFotos)
            {
                FotoParaVista fotoParaVista = new FotoParaVista(){
                    Url  = foto.Url,
                    Descripcion = foto.Descripcion,
                    PublicId = foto.PublicId,
                    EsPerfil = foto.EsPerfil
                };
                listaFotos.Add(fotoParaVista);
            }
            return Ok(listaFotos);
        }

        [HttpPost]
        public IActionResult UploadFoto(string usuarioDocument, [FromForm] FotoParaCreacion fotoParaCreacion)
        {
            if (usuarioDocument != User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                return Unauthorized();
            }
            var getUser = fotosRepo.GetUsuario(usuarioDocument);
            var myFile = fotoParaCreacion.File;

            var uploadResult = new ImageUploadResult();
            if(myFile.Length > 0)
            {
                using(var stream = myFile.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(myFile.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill")
                    };
                    uploadResult = myCloudinary.Upload(uploadParams);
                }
                
            }
            fotoParaCreacion.Url = uploadResult.Uri.ToString();
            fotoParaCreacion.PublicId = uploadResult.PublicId;

            Foto nuevaFoto = new Foto(){
                Url = fotoParaCreacion.Url,
                Agregada = DateTime.Now,
                EsPerfil = false,
                PublicId = fotoParaCreacion.PublicId,
                Usuario = getUser
            };
            
            fotosRepo.AddFoto(nuevaFoto);
            return Ok();
        }
    }
}