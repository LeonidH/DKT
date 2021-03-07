import React from 'react';
import ReactDOM from 'react-dom';
import { Router } from 'react-router-dom';
import { getHistory } from './utils/browser/history-utils';
import { RouteConfig, renderRoutes } from 'react-router-config';
import { routes } from './routes';

function render(appRoutes: RouteConfig) {
    const element = <Router history={getHistory()}>{renderRoutes(appRoutes)}</Router>;
    ReactDOM.render(element, document.getElementById('app'));
}

render(routes);
