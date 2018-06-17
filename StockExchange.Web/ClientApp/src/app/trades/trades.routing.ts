import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MyTradesComponent } from './my-trades/my-trades.component';
import { NewTradeComponent } from './new-trade/new-trade.component';


export const TradesRoutingModule: ModuleWithProviders = RouterModule.forChild([
    {
        path: '',
        component: MyTradesComponent
    }, {
        path: 'new-trade',
        component: NewTradeComponent
    }
]);
