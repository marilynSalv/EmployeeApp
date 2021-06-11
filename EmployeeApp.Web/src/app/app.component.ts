import { Component } from '@angular/core';
import { HierarchyType } from './employees/employee.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'EmployeeApp3.0';
  hierarchyTypes: string[] = ['HSFTerr','HSFMkt', 'HSFS', 'HSFSubMkt', 'PBG'];
  constructor() { 

    const t3: HierarchyType = {
      description: 'test3',
      hierarchyTypeKey: 'HSFMkt',
    };

    const t6: HierarchyType = {
      description: 'Atest3',
      hierarchyTypeKey: 'HSFMkt',
    };

    const t1: HierarchyType = {
      description: 'test1',
      hierarchyTypeKey: 'HSFTerr',
    };
        
    const t2: HierarchyType = {
      description: 'test2',
      hierarchyTypeKey: 'HSFSubMkt',
    };

    const r = this.hierarchyTypes;
    const orderA = this.hierarchyTypes.indexOf("HSFMkt");

    const hierarchyTypesTest = [t3, t1, t2, t6];
    console.log(hierarchyTypesTest);
    
    // let newArr = hierarchyTypesTest.sort((a: HierarchyType, b: HierarchyType) => {
    //   const orderA = this.hierarchyTypes.indexOf(a.hierarchyTypeKey as string);
    //   const orderB = this.hierarchyTypes.indexOf(b.hierarchyTypeKey as string);

    //   const descA = a.description ?? '';
    //   const descb = b.description ?? '';

    //   if (orderA < orderB) {
    //     return -1;
    //   }
    //   if (orderA > orderB) {
    //     return 1;
    //   }else {
    //     if (descA < descb) {
    //       return -1;
    //     }
    //     if (descA > descb) {
    //       return 1;
    //     }

    //     // types and name must be equal
    //     return 0;
    //   }
    // });
    let newArr = hierarchyTypesTest.slice().sort(this.sortTest.bind(this));
    console.log(newArr);
    

  }

  getOrder(key: string): number {
    return this.hierarchyTypes.indexOf(key);
  }

  sortTest(a: HierarchyType, b: HierarchyType): number {
    const orderA = this.hierarchyTypes.indexOf(a.hierarchyTypeKey as string);
    const orderB = this.hierarchyTypes.indexOf(b.hierarchyTypeKey as string);

    const descA = a.description ?? '';
    const descb = b.description ?? '';


    if (orderA < orderB) {
      return -1;
    }
    if (orderA > orderB) {
      return 1;
    }else {
      if (descA < descb) {
        return -1;
      }
      if (descA > descb) {
        return 1;
      }

      // types and name must be equal
      return 0;
    }
  }

}
