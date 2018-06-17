import { Asset } from './asset.model';

export class SettlePair {
    id: number;
    name: string;
    depoNum: string;
    assets: Asset[];
}
