import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  baseurl = 'https://localhost:5001/api/';
  validationError:string[]=[];
  constructor(private http: HttpClient) { }

  ngOnInit(): void { }
  get404Error() {
    this.http.get(this.baseurl + 'Buggy/not-found').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
  get500Error() {
    this.http.get(this.baseurl + 'Buggy/server-error').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
  get401Error() {
    this.http.get(this.baseurl + 'Buggy/auth').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
  get400Error() {
    this.http.get(this.baseurl + 'Buggy/bad-request').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400ValidationError() {
    this.http.post(this.baseurl + 'Account/Register',{}).subscribe({
      next: response => console.log(response),
      error: error =>{
        console.log(error);
        this.validationError=error;
      } 
    })
  }

}
