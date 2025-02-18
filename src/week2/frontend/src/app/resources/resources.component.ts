import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ResourceStore } from './services/resource.store';
import { ResourceDataService } from './services/resource-data.service';
 
@Component({
  selector: 'app-resources',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink, RouterOutlet],
  providers: [ResourceStore, ResourceDataService],
  template: `
    <p>Developer Resources</p>
    <a routerLink="create" class="btn btn-primary">Add A Resource</a>
    <a routerLink="list" class="btn btn-primary">List Of Resources</a>
    <router-outlet />
  `,
  styles: ``,
})
export class ResourcesComponent {}