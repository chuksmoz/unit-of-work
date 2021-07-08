import {autoinject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {Asset} from '../models/asset-model'

@autoinject
export class AssetService {
  
  constructor(private _httpClient: HttpClient){
    
    _httpClient.configure( config => {
      config.useStandardConfiguration()
      .withBaseUrl('http://localhost:5000/api/v1/')
      .withDefaults({
        headers: {
          'content-type': 'application/json',
          'Accept': 'application/json'
        }
      });
      
    });


  }
  

  async save(applicant:Asset): Promise<string>  {
    try {

      const response = await this._httpClient.post('assets', JSON.stringify(applicant));
      if (response.status == 201) {
        return "Success";
      }
      //const data = await response.json();
      if (response.status == 404) {
        return "NotFound";
      }

      if (response.status == 400) {
        return "BadRequest";
      }
      return 'Error';
    } catch (error) {
      console.log(error);
      return "Error";
    }
  
  }

  async getAll():Promise<Asset[]>{
    try {
      const response = await this._httpClient.get('assets');
      console.log(response);
    const applicants: Promise<Asset[]> = await response.json();
    console.log(applicants);
    return applicants;
    } catch (error) {
      console.log(error)
    }
    
  }

  /* all():Promise<IApplicant[]>{
    this._httpClient.get
  } */
}
