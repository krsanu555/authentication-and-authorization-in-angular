import { Injectable } from '@angular/core';
import{Book} from './../book';
import{Observable,of} from 'rxjs';
import{catchError,tap} from 'rxjs/operators';
import{AuthenticationService} from './authentication.service';
import{MessageService} from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class OperationsService {
private posturl='http://localhost:49636/api/dashboard';
  constructor(private authService:AuthenticationService,private messageService:MessageService,private http:HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.posturl)
      .pipe(
        tap(_=>this.messageService.add(`fetched books`)),
        catchError(this.authService.handleError<Book[]>('getBooks', []))
      );
  }
}
