import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = 'https://localhost:32778/v1';

  constructor( private http:HttpClient) {  }

  getProductList(val:any){
    return this.http.post(this.APIUrl+'/Products/GetItems',val);
  }

}
