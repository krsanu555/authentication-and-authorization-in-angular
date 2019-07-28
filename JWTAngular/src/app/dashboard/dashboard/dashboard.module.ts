import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from '../dashboard-routing.module';
import {StudentComponent} from './../student/student.component';
import {TeacherComponent} from './../teacher/teacher.component';
import {AdminComponent} from './../admin/admin.component';
import{DashboardComponent} from './../dashboard.component';
import {AuthGuard} from './../../guards/auth.guard';
import{RoleGuard} from './../../guards/role.guard';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule
  ],

  declarations: [DashboardComponent,StudentComponent, AdminComponent, TeacherComponent],
  providers: [AuthGuard,RoleGuard],
})
export class DashboardModule { }
