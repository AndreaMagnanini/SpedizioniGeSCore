import React from 'react';
import FerrariTheme from "../styles/FerrariTheme";
import {ThemeProvider} from "@material-ui/core";

function Shipments(props) {
    return (
        <ThemeProvider theme={FerrariTheme}>
        <div>
            Shipments
        </div>
        </ThemeProvider>
    );
}

export default Shipments;