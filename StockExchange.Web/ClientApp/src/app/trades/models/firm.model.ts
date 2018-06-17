import { SettlePair } from './settle-pair.model';
import { Trade } from './trade.model';

export class Firm {
    id: number;
    name: string;
    fullName: string;
    settlePairs: SettlePair[];
    trades?: Trade[];
}
