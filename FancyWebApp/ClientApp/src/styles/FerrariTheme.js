// @ts-nocheck
import { createTheme } from '@material-ui/core/styles';

const theme = createTheme({
    overrides: {
        MuiCssBaseline: {
            '@global': {
                body: {
                    backgroundColor: "#212121",
                    margin: "0px"
                },
                '*::-webkit-scrollbar': {
                    width: "8px",
                    height: "8px",
                },
                '*::-webkit-scrollbar-track': {
                    backgroundColor: "#eeeeee",
                    borderRadius: "4px"
                },
                '*::-webkit-scrollbar-thumb':{
                    backgroundColor: "#D41217",
                    borderRadius: "4px"
                }
            },
        },
    },
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
        },
        background: {
            default: "#212121"
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
        },
        MuiFormControlLabel: {
            styleOverrides: {
                typography:{
                    color: "#eeeeee"
                }
            }
        }
    }
});
export default theme;