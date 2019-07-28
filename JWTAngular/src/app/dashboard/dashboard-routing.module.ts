import { NgModule } from '@angular/core';
import { RouterModule,Routes } from '@angular/router';
import {DashboardComponent} from './dashboard.component';
import {AuthGuard} from './../guards/auth.guard';
import {RoleGuard} from './../guards/role.guard';
import{TeacherComponent} from './teacher/teacher.component';
import{StudentComponent} from './student/student.component';
import{AdminComponent} from './admin/admin.component';
const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
    children: [
     // { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'admin', component: AdminComponent,canActivate:[RoleGuard],data: {role: 'admin'}},
      { path: 'student', component: StudentComponent,canActivate: [RoleGuard],
    data: {role: 'student'}},
     { path: 'teacher', component: TeacherComponent,canActivate: [RoleGuard],
    data: {role: 'teacher'}
 }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
