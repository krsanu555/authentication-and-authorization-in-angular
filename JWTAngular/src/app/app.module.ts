import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import{ReactiveFormsModule,FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { PagenotfoundComponent }from './pagenotfound/pagenotfound.component';
import{DashboardModule} from './dashboard/dashboard/dashboard.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import{AuthInterceptor} from './Interceptors/auth-interceptor';
import{ErrorInterceptor} from './Interceptors/error-interceptor';
import { AdminComponent } from './dashboard/admin/admin.component';
import { TeacherComponent } from './dashboard/teacher/teacher.component';
import { StudentComponent } from './dashboard/student/student.component';
import { HighlightDirective } from './highlight.directive';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PagenotfoundComponent,
    HighlightDirective
  
  ],
  imports: [
    BrowserModule,
    DashboardModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    HttpClientModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
