import * as React from 'react';
import { Event } from '../../abstractions/Event';

// Define the props interface
interface EventSelectorProps {
    options: Event[],
    callback: Function,
    style: object
}

// Declare the component's type
declare const EventSelector: React.FC<EventSelectorProps>;

// Export the component
export default EventSelector;