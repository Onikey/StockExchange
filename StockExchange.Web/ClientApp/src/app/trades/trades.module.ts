import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatButtonModule, MatFormFieldModule, MatInputModule, MatAutocompleteModule } from '@angular/material';

import { TradesRoutingModule } from './trades.routing';

import { TradeService } from './services/trade.service';

import { NewTradeComponent } from './new-trade/new-trade.component';
import { MyTradesComponent } from './my-trades/my-trades.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TradesRoutingModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
  ],
  declarations: [
    NewTradeComponent,
    MyTradesComponent
  ],
  providers: [
    TradeService
  ]
})
export class TradesModule { }
