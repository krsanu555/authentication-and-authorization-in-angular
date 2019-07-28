import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from './../Services/authentication.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private _authService:AuthenticationService) { }
  ngOnInit() {
  }
  logout() {
    this._authService.logout();
  }
}
