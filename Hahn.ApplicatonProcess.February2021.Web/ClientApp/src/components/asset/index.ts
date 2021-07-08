import { DialogService } from 'aurelia-dialog';
import {autoinject} from 'aurelia-framework';
import { Asset } from '../../common/models/asset-model';
import { AssetService } from '../../common/services/asset-service';

@autoinject
export class Index {
  asset: Asset[] = [];

  constructor(private _assetService: AssetService, private _dialogService: DialogService) {
  }

  async attached(): Promise<void>{
    this.asset = await this._assetService.getAll();
  }
}
