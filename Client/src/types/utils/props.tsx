import { RouteConfigComponentProps } from 'react-router-config';

export type WithRouteProps<Props = object, Params = object> = Props &
    RouteConfigComponentProps<Params>;
