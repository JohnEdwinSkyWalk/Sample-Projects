import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-all-mails-data',
  templateUrl: './all-mails.component.html'
})
export class AllMailsComponent {
  public allmails: IAllMails[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IAllMails[]>(baseUrl + 'ExternalAPI').subscribe(result => {
      this.allmails = result;
    }, error => console.error(error));
  }
}

interface IAllMails {
  userId: number;
  id: number;
  title: string;
  body: string;
}
