import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

import { TradeService } from '../services/trade.service';

import { Issue, Firm } from '../models';

@Component({
  selector: 'app-new-trade',
  templateUrl: './new-trade.component.html',
  styleUrls: ['./new-trade.component.css']
})
export class NewTradeComponent implements OnInit {
  public issues: Observable<Issue[]>;
  public confFirms: Observable<Firm[]>;
  private currentFirm: Firm;

  public tradeForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private tradeService: TradeService) {
  }

  ngOnInit() {
    this.issues = this.tradeService.getIssues();
    this.confFirms = this.tradeService.getFirms();

    this.tradeService.getCurrentFirm()
      .subscribe(firm => this.currentFirm = firm);

    this.onReset();
  }

  public onReset() {
    this.tradeForm = this.formBuilder.group({
      issue: ['', Validators.required],
      confFirm: ['', Validators.required],
      settlePair: ['', Validators.required],
      price: ['', Validators.required],
      qty: ['', Validators.required],
      memo: ['']
    });
  }

}
