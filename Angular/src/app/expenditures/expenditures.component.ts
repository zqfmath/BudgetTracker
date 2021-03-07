import { Component, OnInit } from '@angular/core';
import { ExpendituresService } from '../core/services/expenditures.service';
import { Expenditure } from '../shared/models/expenditure';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl,ReactiveFormsModule } from '@angular/forms';



@Component({
  selector: 'app-expenditures',
  templateUrl: './expenditures.component.html',
  styleUrls: ['./expenditures.component.css']
})



export class ExpendituresComponent implements OnInit {

  updateExpenditureForm: FormGroup;
  addExpenditureForm: FormGroup;
  expenditures: Expenditure[]=[];
  updatedExpenditureId:number;
  displayedColumns: string[] = ['userId', 'amount', 'desription', 'expDate', 'remarks','update','delete'];
  constructor(private fb: FormBuilder,private expendituresService: ExpendituresService,private modalService: NgbModal) {
    this.updatedExpenditureId=-1;
    this.updateExpenditureForm = this.fb.group({
      userId: [0,[]],
      amount: [0.0,[]],
      desription: ['',[]],
      expDate: ['',[]],
      remarks: ['',[]]
    });
    this.addExpenditureForm = this.fb.group({
      userId: [0,[]],
      amount: [0.0,[]],
      desription: ['',[]],
      expDate: ['',[]],
      remarks: ['',[]]
    });

  }

  ngOnInit(): void {
    this.expendituresService.gettAllExpenditures().subscribe(
      g=>{this.expenditures=g},
      (err) => {window.alert("Failed to load data.")}
    )
  }
openAdd(content:any){
  this.modalService.open(content,{size:'lg'})
}
openUpdate(content:any,id:number){
  this.updatedExpenditureId=id
  this.modalService.open(content,{size:'lg'})
}

onSubmitUpdate(){

  const date = this.updateExpenditureForm.value.expDate
  const expenditure={id:this.updatedExpenditureId,
    userId:this.updateExpenditureForm.value.userId,
    amount: this.updateExpenditureForm.value.amount,
    desription:this.updateExpenditureForm.value.desription,
    expDate: date?date.year+"-"+('0'+date.month).slice(-2)+"-"+('0'+date.day).slice(-2):null,
    remarks: this.updateExpenditureForm.value.remarks
  }
  this.expendituresService.update(expenditure).subscribe(
    g=>{console.log(g)},
    (err) => {window.alert("Failed to Update. There may be format error, or the email has been occupied.")}
  )
  window.location.reload();
}

onSubmitAdd(){
  const date = this.addExpenditureForm.value.expDate
  const expenditure={
    userId:this.addExpenditureForm.value.userId,
    amount: this.addExpenditureForm.value.amount,
    desription:this.addExpenditureForm.value.desription,
    expDate: date?date.year+"-"+('0'+date.month).slice(-2)+"-"+('0'+date.day).slice(-2):null,
    remarks: this.addExpenditureForm.value.remarks
  }
  this.expendituresService.add(expenditure).subscribe(
    g=>{console.log(g)},
    (err) => {window.alert("Failed to Add. There may be format error, or the userId doesn't exist.")}
  )
  window.location.reload();
}

 
  delete(id:number){
    this.expendituresService.delete(id).subscribe(
      g=>{console.log(g)},
      (err) => {window.alert("Failed to delete. It may already be deleted.")}
    )
    window.location.reload();
  }

}


