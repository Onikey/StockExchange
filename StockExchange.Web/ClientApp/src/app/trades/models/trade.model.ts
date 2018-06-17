import { Issue } from './issue.model';
import { Firm } from './firm.model';
import { SettlePair } from './settle-pair.model';
import { TradeStatus } from './trade-status.enum';

export class Trade {
    id: number;
    issue: Issue;
    price: number;
    qty: number;
    volumn: number;
    tradeMomemt: Date;
    affirmMoment: Date;
    initFirm: Firm;
    initSettlePair: SettlePair;
    initAction: string;
    initMemo: string;
    confFirm: Firm;
    confSettlePair: SettlePair;
    confAction: string;
    confMemo: string;
    status: TradeStatus;
}
