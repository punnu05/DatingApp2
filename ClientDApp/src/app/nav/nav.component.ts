import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { user } from '../_Models/user';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}

  constructor(public accntSservice: AccountService) { }


  ngOnInit(): void { }

  login() {
    this.accntSservice.login(this.model).subscribe({
      next: response => {
        console.log(response);
        
      },
      error: error => console.log(error)
    })
  } 
  logout(){
    this.accntSservice.logout()
  }  

 
}
