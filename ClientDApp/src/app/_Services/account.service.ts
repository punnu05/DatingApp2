import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { user } from '../_Models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseurl = 'https://localhost:5001/api/';
  private currentUserSource= new BehaviorSubject<user | null>(null);
  currentUser$ =this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post<user>(this.baseurl + 'Account/Login', model).pipe(map((response: user) => {
      const user = response;
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      }
    }));
  }
setCurrentUser(user:user){
  this.currentUserSource.next(user);
}

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
