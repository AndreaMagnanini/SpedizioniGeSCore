import * as React from 'react';
import { Location } from '../../abstractions/Location';

// Define the props interface
interface LocationSelectorProps {
    options: Location[],
    callback: Function,
    style: object
}

// Declare the component's type
declare const LocationSelector: React.FC<LocationSelectorProps>;

// Export the component
export default LocationSelector;