import { Component, OnInit } from '@angular/core';
import { IncomesService } from '../core/services/incomes.service';
import { Income } from '../shared/models/income';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl,ReactiveFormsModule } from '@angular/forms';



@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})



export class IncomesComponent implements OnInit {

  updateIncomeForm: FormGroup;
  addIncomeForm: FormGroup;
  incomes: Income[]=[];
  updatedIncomeId:number;
  displayedColumns: string[] = ['userId', 'amount', 'desription', 'incomeDate', 'remarks','update','delete'];
  constructor(private fb: FormBuilder,private incomesService: IncomesService,private modalService: NgbModal) {
    this.updatedIncomeId=-1;
    this.updateIncomeForm = this.fb.group({
      userId: [0,[]],
      amount: [0.0,[]],
      desription: ['',[]],
      incomeDate: ['',[]],
      remarks: ['',[]]
    });
    this.addIncomeForm = this.fb.group({
      userId: [0,[]],
      amount: [0.0,[]],
      desription: ['',[]],
      incomeDate: ['',[]],
      remarks: ['',[]]
    });

  }

  ngOnInit(): void {
    this.incomesService.gettAllIncomes().subscribe(
      g=>{this.incomes=g},
      (err) => {window.alert("Failed to load data.")}
    )
  }
openAdd(content:any){
  this.modalService.open(content,{size:'lg'})
}
openUpdate(content:any,id:number){
  this.updatedIncomeId=id
  this.modalService.open(content,{size:'lg'})
}

onSubmitUpdate(){

  const date = this.updateIncomeForm.value.incomeDate
  const income={id:this.updatedIncomeId,
    userId:this.updateIncomeForm.value.userId,
    amount: this.updateIncomeForm.value.amount,
    desription:this.updateIncomeForm.value.desription,
    incomeDate: date?date.year+"-"+('0'+date.month).slice(-2)+"-"+('0'+date.day).slice(-2):null,
    remarks: this.updateIncomeForm.value.remarks
  }
  this.incomesService.update(income).subscribe(
    g=>{console.log(g)},
    (err) => {window.alert("Failed to Update. There may be format error, or the email has been occupied.")}
  )
  window.location.reload();
}

onSubmitAdd(){
  const date = this.addIncomeForm.value.incomeDate
  const income={
    userId:this.addIncomeForm.value.userId,
    amount: this.addIncomeForm.value.amount,
    desription:this.addIncomeForm.value.desription,
    incomeDate: date?date.year+"-"+('0'+date.month).slice(-2)+"-"+('0'+date.day).slice(-2):null,
    remarks: this.addIncomeForm.value.remarks
  }
  this.incomesService.add(income).subscribe(
    g=>{console.log(g)},
    (err) => {window.alert("Failed to Add. There may be format error, or the userId doesn't exist.")}
  )
  window.location.reload();
}

 
  delete(id:number){
    this.incomesService.delete(id).subscribe(
      g=>{console.log(g)},
      (err) => {window.alert("Failed to delete. It may already be deleted.")}
    )
    window.location.reload();
  }

}


