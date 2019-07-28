import { Component, OnInit } from '@angular/core';
import{AuthenticationService} from './../Services/authentication.service';

@Component({
  selector: 'app-pagenotfound',
  templateUrl: './pagenotfound.component.html',
  styleUrls: ['./pagenotfound.component.css']
})
export class PagenotfoundComponent implements OnInit {

  constructor(private _authService:AuthenticationService) { 
    setTimeout(() => {  this._authService.logout() },20000);
  }

  ngOnInit() {
  }

}
