import * as React from 'react';
import { Airport } from '../../abstractions/Airport';

// Define the props interface
interface AirportSelectorProps {
    options: Airport[],
    callback: Function,
    style: object
}

// Declare the component's type
declare const AirportSelector: React.FC<AirportSelectorProps>;

// Export the component
export default AirportSelector;