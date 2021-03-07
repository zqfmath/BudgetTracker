import { Component, OnInit } from '@angular/core';
import { UsersService } from '../core/services/users.service';
import { User } from '../shared/models/user';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl,ReactiveFormsModule } from '@angular/forms';



@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})



export class UsersComponent implements OnInit {

  updateUserForm: FormGroup;
  addUserForm: FormGroup;
  users: User[]=[];
  updatedUserId:number;
  displayedColumns: string[] = ['email', 'password', 'fullname', 'joinedOn','update','delete'];
  constructor(private fb: FormBuilder,private usersService: UsersService,private modalService: NgbModal) {
    this.updatedUserId=-1;
    this.updateUserForm = this.fb.group({
      email:['',[]],
      password:['',[]],
      fullname:['',[]],
      joinedOn:['',[]]
    });
    this.addUserForm = this.fb.group({
      email:['',[]],
      password:['',[]],
      fullname:['',[]],
      joinedOn:['',[]]
    });

  }

  ngOnInit(): void {
    this.usersService.gettAllUsers().subscribe(
      g=>{this.users=g},
      (err) => {window.alert("Failed to load data.")}
    )
  }
openAdd(content:any){
  this.modalService.open(content,{size:'lg'})
}
openUpdate(content:any,id:number){
  this.updatedUserId=id
  this.modalService.open(content,{size:'lg'})
}

onSubmitUpdate(){

  const date = this.updateUserForm.value.joinedOn
  const user={id:this.updatedUserId,
    email:this.updateUserForm.value.email,
    password: this.updateUserForm.value.password,
    fullname:this.updateUserForm.value.fullname,
    joinedOn: date?date.year+"-"+('0'+date.month).slice(-2)+"-"+('0'+date.day).slice(-2):null
  }
  this.usersService.update(user).subscribe(
    g=>{console.log(g)},
    (err) => {window.alert("Failed to Update. There may be format error, or the email has been occupied.")}
  )
  window.location.reload();
}

onSubmitAdd(){
  const date = this.addUserForm.value.joinedOn
  const user={
    email:this.addUserForm.value.email,
    password: this.addUserForm.value.password,
    fullname:this.addUserForm.value.fullname,
    joinedOn: date?date.year+"-"+('0'+date.month).slice(-2)+"-"+('0'+date.day).slice(-2):null
  }
  this.usersService.add(user).subscribe(
    g=>{console.log(g)},
    (err) => {window.alert("Failed to Add. There may be format error, or the email has been occupied.")}
  )
  window.location.reload();
}

 
  delete(id:number){
    this.usersService.delete(id).subscribe(
      g=>{console.log(g)},
      (err) => {window.alert("Failed to delete. It may already be deleted.")}
    )
    window.location.reload();
  }

}


