import {PLATFORM} from 'aurelia-pal';
import {Router, RouterConfiguration} from 'aurelia-router';


export class App {
  public router: Router;

  public configureRouter(config: RouterConfiguration, router: Router): Promise<void> | PromiseLike<void> | void{
    config.title = 'Hahn Application';
    config.map([
      {
        route: ['', 'index'],
        name: 'index',
        moduleId: PLATFORM.moduleName('./components/asset/index'),
        nav: true,
        title: 'Asset'
      },
      {
        route: '/create',
        name: 'create',
        moduleId: PLATFORM.moduleName('./components/asset/create'),
        nav: true,
        title: 'Create Asset'
      },
      {
        route: '/success',
        name: 'success',
        moduleId: PLATFORM.moduleName('./components/asset/success'),
        nav: true,
        title: 'success Message'
      }
    ]);
    config.mapUnknownRoutes('./components/asset/create');
    this.router = router;
  }
  
}
