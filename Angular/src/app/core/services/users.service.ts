import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {User} from 'src/app/shared/models/user';
import {ApiService} from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  url:string
  constructor(private apiService:ApiService) { 
    this.url='/User'
  }
    gettAllUsers(): Observable<any[]>{
      return this.apiService.getAll(this.url)
  }
  delete(id:number){
     return this.apiService.delete(this.url,id)
  }
  add(user:any){
    return this.apiService.create(this.url,user);
  }
  update(user:any){
    return this.apiService.update(this.url,user);
  }
}
