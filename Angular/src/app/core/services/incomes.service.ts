import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Income} from 'src/app/shared/models/income';
import {ApiService} from './api.service';

@Injectable({
  providedIn: 'root'
})
export class IncomesService {

  url:string
  constructor(private apiService:ApiService) { 
    this.url='/Income'
  }
    gettAllIncomes(): Observable<any[]>{
      return this.apiService.getAll(this.url)
  }
  delete(id:number){
     return this.apiService.delete(this.url,id)
  }
  add(income:any){
    return this.apiService.create(this.url,income);
  }
  update(income:any){
    return this.apiService.update(this.url,income);
  }
}
