import { Component, OnInit } from '@angular/core';
import{OperationsService} from './../../Services/operations.service';
import{Book} from './../../book';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private operationservice:OperationsService) { }
books:Book[];
  ngOnInit() {
  }
  onClick()
  {
this.operationservice.getBooks().subscribe(books=>this.books=books);
  }

}
