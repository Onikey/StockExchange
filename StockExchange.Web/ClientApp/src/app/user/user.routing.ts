import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { UserResolver } from '../core/auth';

import { InformationComponent } from './information/information.component';

export const AccountRoutingModule: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'information',
        component: InformationComponent,
        resolve: {
            user: UserResolver
        },
        data: { title: 'Информация о Пользователе' },
    },
    {
        path: '',
        redirectTo: 'information',
        pathMatch: 'full'
    }
]);
