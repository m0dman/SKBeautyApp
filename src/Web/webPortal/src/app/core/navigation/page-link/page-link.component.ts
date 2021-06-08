import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-page-link',
  templateUrl: './page-link.component.html',
  styleUrls: ['./page-link.component.scss']
})
export class PageLinkComponent implements OnInit {
  @Input()
  pageName: string = "";
  @Input()
  pageLink: string = "";
  @Input()
  pageIcon: string = "";
  
  constructor() { }
  
  ngOnInit(): void {
  }
}
