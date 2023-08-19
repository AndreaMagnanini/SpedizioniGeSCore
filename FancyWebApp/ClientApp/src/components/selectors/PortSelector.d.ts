import * as React from 'react';
import { Port } from '../../abstractions/Port';

// Define the props interface
interface PortSelectorProps {
    options: Port[],
    callback: Function,
    style: object
}

// Declare the component's type
declare const PortSelector: React.FC<PortSelectorProps>;

// Export the component
export default PortSelector;