import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/auth';


const appRoutes: Routes = [
    {
        path: 'home',
        loadChildren: './home/home.module#HomeModule',
        canActivate: [AuthGuard]
    },
    { path: 'account', loadChildren: './account/account.module#AccountModule' },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
];

export const AppRoutingModule: ModuleWithProviders = RouterModule.forRoot(appRoutes);
