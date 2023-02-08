import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { AccountService } from '../_Services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accntservice: AccountService, private toastr: ToastrService) { }
  canActivate(): Observable<boolean> {
     return this.accntservice.currentUser$.pipe(map(user =>{
      if(user) return true;
      else{
        this.toastr.error('you shall not pass');
        return false;
      }
     }))
  }

}
