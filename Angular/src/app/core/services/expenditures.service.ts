import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Expenditure} from 'src/app/shared/models/expenditure';
import {ApiService} from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ExpendituresService {

  url:string
  constructor(private apiService:ApiService) { 
    this.url='/Expenditure'
  }
    gettAllExpenditures(): Observable<any[]>{
      return this.apiService.getAll(this.url)
  }
  delete(id:number){
     return this.apiService.delete(this.url,id)
  }
  add(expenditure:any){
    return this.apiService.create(this.url,expenditure);
  }
  update(expenditure:any){
    return this.apiService.update(this.url,expenditure);
  }
}
