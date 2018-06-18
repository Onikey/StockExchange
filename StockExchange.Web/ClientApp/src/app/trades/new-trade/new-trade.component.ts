import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { TradeService } from '../services/trade.service';

import { Issue, Firm } from '../models';

@Component({
  selector: 'app-new-trade',
  templateUrl: './new-trade.component.html',
  styleUrls: ['./new-trade.component.css']
})
export class NewTradeComponent implements OnInit {
  public issues: Issue[];
  public confFirms: Firm[];
  private currentFirm: Firm;

  public confFirmFullName: string = null;
  public issueFullName: string = null;

  public tradeAction = 'P';

  public tradeForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private tradeService: TradeService) {
  }

  ngOnInit() {
    this.tradeService.getIssues()
      .subscribe(issues => this.issues = issues);

    this.tradeService.getFirms()
      .subscribe(firms => this.confFirms = firms);

    this.tradeService.getCurrentFirm()
      .subscribe(firm => this.currentFirm = firm);

    this.onReset();
  }

  get f() { return this.tradeForm.controls; }

  public onReset() {
    this.tradeForm = this.formBuilder.group({
      issue: ['', Validators.required],
      confFirm: ['', Validators.required],
      settlePair: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0.00000000001)]],
      qty: [0, [Validators.required, Validators.min(0.00000000001)]],
      memo: ['']
    });

    this.tradeForm.controls['issue'].valueChanges.subscribe(ch => this.onIssueChange());
    this.tradeForm.controls['confFirm'].valueChanges.subscribe(ch => this.onConfFirmChange());
  }

  public onIssueChange() {
    this.issueFullName = this.issues.find(x => x.name === this.tradeForm.controls['issue'].value).fullName;
  }

  public onConfFirmChange() {
    this.confFirmFullName = this.confFirms.find(x => x.name === this.tradeForm.controls['confFirm'].value).fullName;
  }

  public changeTradeAction() {
    this.tradeAction = this.tradeAction === 'P' ? 'S' : 'P';
  }

  public onSubmit() {
    this.tradeService.createTrade({
      initFirmName: this.currentFirm.name,
      initAction: this.tradeAction,
      confFirmName: this.tradeForm.controls['confFirm'].value,
      initMemo: this.tradeForm.controls['memo'].value,
      initSettlePairName: this.tradeForm.controls['settlePair'].value,
      issueName: this.tradeForm.controls['issue'].value,
      price: this.tradeForm.controls['price'].value,
      qty: this.tradeForm.controls['qty'].value
    }).subscribe();
  }
}
