import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  LoggedIn = false;
  constructor(private accntSservice: AccountService) { }


  ngOnInit(): void { }

  login() {
    this.accntSservice.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.LoggedIn = true;
      },
      error: error => console.log(error)
    })
  }
  logout(){
    this.LoggedIn=false;
  }
}
