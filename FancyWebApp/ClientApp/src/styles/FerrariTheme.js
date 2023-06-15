import { createTheme } from '@material-ui/core/styles';

const theme = createTheme({
    palette: {
        primary: {
            main: "#D41217",
        },
        secondary: {
            main: "#ffc107",
        },
        text:{
            primary: "#212121",
            secondary: "#fafafa",
            hint: "#D41217"
        }
    },
    typography: {
        fontFamily: 'Michroma',
        fontWeightLight: '300',
        fontWeightRegular: '400',
        fontWeightMedium: '500',
        fontWeightBold: '600',
    },
    components: {
        MuiDrawer: {
            styleOverrides: {
                paper: {
                    background: "#000"
                }
            }
        }
    }
});
export default theme;