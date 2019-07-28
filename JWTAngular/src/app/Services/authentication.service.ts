import { Injectable } from '@angular/core';
import{Observable,of} from 'rxjs';
import{catchError,tap} from 'rxjs/operators';
import {User} from './../User';
import {MessageService} from './message.service';
import decode from 'jwt-decode';
import * as moment from "moment";
import { Router } from '@angular/router';

import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
private posturl='http://localhost:49636/api/login';
  constructor(private http:HttpClient,private messageService:MessageService,private router:Router) { }

  login (user: User): Observable<any> {
   
    return this.http.post<any>(this.posturl, user, httpOptions).pipe(
      tap(_ => this.log(`logged in UserName =${user.UserName}`)),
      catchError(this.handleError<any>('LogIn'))
    );
  }

  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {


     // console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
  private log(message: string) {
    this.messageService.add(`LoginService: ${message}`);
  }

setToken(token)
{
  const expiresAt = moment().add(decode(token).exp,'second');
//console.log(decode(token).exp);
  localStorage.setItem("TokenInfo",token);
  localStorage.setItem("expires_at",JSON.stringify(expiresAt.valueOf()))
}
decodetoken() {
  return decode(localStorage.getItem('TokenInfo'));
}
  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('TokenInfo');
    localStorage.removeItem('expires_at');
    this.router.navigate(['login']);
}
getExpiration() {
  const expiration = localStorage.getItem("expires_at");
  const expiresAt = JSON.parse(expiration);
  return moment(expiresAt);
} 
public isLoggedIn() {
  return moment().isBefore(this.getExpiration());
}

isLoggedOut() {
  return !this.isLoggedIn();
}
}
