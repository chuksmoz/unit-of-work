import { departmentEnum } from './../../common/enum/department';
import {autoinject, computedFrom} from 'aurelia-framework';
import {I18N} from 'aurelia-i18n';
import {ValidationRules, ValidationControllerFactory, ValidationController, validateTrigger, Validator} from 'aurelia-validation';
import { BootstrapFormRenderer } from 'common/util/bootstrap-form-renderer';
import { DialogService } from 'aurelia-dialog';
import {Asset} from '../../common/models/asset-model';
import {AssetService} from '../../common/services/asset-service';
import {Router} from 'aurelia-router';
import { Prompt } from 'components/modals/prompt';
//import { Prompt } from 'components/modals/promt';


@autoinject
export class Create {
  //router: Router;
  asset: Asset = new Asset();
  departments = departmentEnum;
  controller: ValidationController;
  enableBtn = false;

  constructor(private _applicantService: AssetService, validationFactory: ValidationControllerFactory, private _router: Router, private _dialogService: DialogService, private _i18N:I18N) {
    this.controller = validationFactory.createForCurrentScope();
    this.controller.validateTrigger = validateTrigger.changeOrBlur;
    
    
  }
  

  async setLocale(locale: string): Promise<void>{
    const res = await this._i18N.setLocale(locale);
    
    
  }
 
  async submit() :Promise<void>{
    const result = await this._applicantService.save(this.asset);
    if (result == "Success") {
      this._router.navigateToRoute('success')
    } else if(result == "NotFound"){
      this.showModal("Invalid CountryOfOrigin");
    }else if(result == "BadRequest"){
      this.showModal("Invalid Input");
    }else {
      this.showModal("system error");
    }

  } 

  reset(): void{
    this.asset = null;
  }
  
  showModal(message: string): void {
    this._dialogService.open({ viewModel: Prompt, model: message, lock: false }).whenClosed(response => {
      /* if (!response.wasCancelled) {
        
      } else {
      } */
    });
  }
  
  activate(): void {
    /* if(this.asset){
      ValidationRules
      .ensure((p: Asset) => p.assetName).required().minLength(5)
      .ensure((p: Asset) => p.eMailAdressOfDepartment).required().email()
      .ensure((p: Asset) => p.countryOfDepartment).required().range(20,60)
      .ensure((p: Asset) => p.department).required().minLength(5)
      .ensure((p: Asset) => p.purchaseDate).required().minLength(10)
      .on(this.asset);
      this.controller.addRenderer(new BootstrapFormRenderer());
    } */
  }

  deactivate(): void{
    this.controller.reset();
  }


}
