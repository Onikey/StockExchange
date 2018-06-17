import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { UserResolver } from '../core/auth';

export const HomeRoutingModule: ModuleWithProviders = RouterModule.forChild([
    {
        path: '',
        component: HomeComponent,
        resolve: {
            user: UserResolver
        },
        children: [
            // {
            //     path: 'user',
            //     loadChildren: '../user/user.module#UserModule',
            // },
            {
                path: 'trades',
                loadChildren: '../trades/trades.module#TradesModule',
            }, {
                path: '',
                redirectTo: 'trades',
                pathMatch: 'full'
            }
        ]
    }
]);
