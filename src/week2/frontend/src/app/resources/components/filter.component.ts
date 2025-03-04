import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ResourceStore } from '../services/resource.store';

@Component({
  selector: 'app-resource-filter',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div>
      <select (change)="changeTheFilter($event)" class="input input-bordered">
        @for (tag of store.tags(); track tag) {
          <option value="{{ tag }}">{{ tag }}</option>
        }
      </select>
    </div>
  `,
  styles: ``,
})
export class FilterComponent {
  store = inject(ResourceStore);
  router = inject(Router);
  changeTheFilter(event: any): void {
    this.router.navigate([], {
      queryParams: { filter: event.target.value },
    });
  }
}
