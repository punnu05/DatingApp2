import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
// import { ToastrService } from 'ngx-toastr/toastr/toastr.service';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{

 @Output() cancelRegister =new EventEmitter();
 model:any ={};


 constructor(private accountservice:AccountService,private toastr:ToastrService) { }
  ngOnInit(): void { }
  
  register(){
   this.accountservice.register(this.model).subscribe({
    next:()=>{
     // console.log(response);
      this.cancel();
    },
    error:error=>{
      this.toastr.error(error.error)
console.log(error)
    }
   })
  }
  cancel(){
    this.cancelRegister.emit(false);
  }
}
