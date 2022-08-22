Title: How to use BehaviourSubject to share the data to other components in Angular
Published: 27/04/2019
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-use-behavioursubject-to-share-the-data-to-other-components-in-angular
Tags:
  - Angular
---
We use `BehaviourSubject` to share the data with multiple components using a shared service. 

For example, if we want to notify other components of the data change. Then we have to do two simple tasks.

1.  We have to create a `BehaviourSubject` & an `Observable` of that `BehaviourSubject` in a service.
2.  Secondly, we can subscribe to that `Observable` in other components.

I have created the below service to notify another component to log out the user from the application.

## 1. data.service.ts
Read the comments marked with 1, 2, 3 & 4 steps. They explain their usage itself.
```ts
import { Injectable } from '@angular/core';

//1. Import BehaviorSubject from rxjs module
import { BehaviorSubject } from 'rxjs/BehaviorSubject'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  //2. Create the data which we want to share with all the components
  private logoutStatus = new BehaviorSubject(false);

  //3. Now we want to broadcast this message or data, so we create an observable
  getLogoutStatus = this.logoutStatus.asObservable();

  constructor() { }

  //4. Create a method that updates the data (Behaviour Subject)
  logoutUser(){
    this.logoutStatus.next(true);
  }
}

```

## 2. logout.ts
In this, the `logoutUser()` method of `DataService` will update the value of `BehaviourSubject` so that all & the observable (i.e. `getLogoutStatus`) of this `BehaviourSubject` will broadcast the message to all subscribers.

```ts
import { Component } from '@angular/core';
import { DataService } from './../../services/data.service'

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  constructor(private dataService : DataService) { }

  ngOnInit() {
    console.log("ngOnInit called");
  }

  onLogout(){
    this.dataService.logoutUser();
  }
}
```

## 3. app.component.ts
In this component, we have subscribed the`getLogoutStatus` observable. The subscription handle will be executed every time whenever there is a change in the value of `BehaviourSubject`.

```ts
import { Component } from '@angular/core';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MyApp';

  constructor(private dataService : DataService) { }

  ngOnInit() {
    this.dataService.getLogoutStatus.subscribe((data) => {
      if(data === true){
        alert("User has been loggedout");
      }
    })
  }
}
```

                
