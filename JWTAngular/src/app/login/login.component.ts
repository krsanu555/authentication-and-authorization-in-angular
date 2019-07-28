import { Component, OnInit } from '@angular/core';
import{FormBuilder,Validators} from '@angular/forms';
import {AuthenticationService}from './../Services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import{MessageService} from './../Services/message.service';
import { first } from 'rxjs/operators';
import {User} from '../User'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  submitted=false;
  error;
  loginForm;
  constructor(private fb:FormBuilder,private authservice:AuthenticationService,private router:Router,public messageService:MessageService) {
    this.loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  }); }

  ngOnInit() {
  }
onSubmit(loginDetails:User)
{this.authservice.login(loginDetails).pipe(first())
  .subscribe(
    res => {
    if(res)
    {
      this.authservice.setToken(res);
      this.router.navigate(['dashboard']);
      
    }
    else{
      this.loginForm.reset();
     this.error="Invalid Credentials"; 
    }
    }
    );

}

get messageInService(){ return this.messageService.messages;}
}
