import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

// import { ToastrService } from 'ngx-toastr/toastr/toastr.service';
import { ToastrService } from 'ngx-toastr';

import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}

  constructor(public accntSservice: AccountService,private router:Router,private toastr:ToastrService) { }


  ngOnInit(): void { }

  login() {
    this.accntSservice.login(this.model).subscribe({
      next: _ => this.router.navigateByUrl('/members'),
      error: error => this.toastr.error(error.error)
      
    })
  } 
  logout(){
    this.accntSservice.logout()
    this.router.navigateByUrl('/')
  }  

}
