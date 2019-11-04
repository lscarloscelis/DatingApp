import { HomeComponent } from './app/home/home.component';
import { LoginComponent } from './app/login/login.component';
import { RegisterComponent } from './app/register/register.component';
import { UserhomeComponent } from './app/userhome/userhome.component';
import { AuthGuard } from './app/_guards/auth.guard';
import { MensajesComponent } from './app/mensajes/mensajes.component';
import { ListaComponent } from './app/lista/lista.component';
import { MatchesComponent } from './app/matches/matches.component';

export const appRoutes = [
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'userhome', component: UserhomeComponent, canActivate: [AuthGuard] },
    { path: 'mensajes', component: MensajesComponent, canActivate: [AuthGuard] },
    { path: 'listas', component: ListaComponent, canActivate: [AuthGuard] },
    { path: 'matches', component: MatchesComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: 'home'}
]
