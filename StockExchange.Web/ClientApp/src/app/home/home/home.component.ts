import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';

import { User, AuthService } from '../../core/auth';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public currentUser: User = null;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.currentUser = this.activatedRoute.snapshot.data['user'];
  }

  public logout() {
    this.authService.logout()
      .subscribe(() => this.router.navigate(['/account/login']));
  }

}
