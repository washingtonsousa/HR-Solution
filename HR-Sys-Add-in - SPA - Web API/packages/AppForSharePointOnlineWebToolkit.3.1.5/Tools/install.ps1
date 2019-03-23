param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath common.psm1) -Force

try {

    # Indicates if the current project is a VB project
    $IsVbProject = ($project.CodeModel.Language -eq [EnvDTE.CodeModelLanguageConstants]::vsCMLanguageVB)

    # Indicates if the current project is an MVC project
    $IsMvcProject = ($project.Object.References | Where-Object { $_.Identity -eq "System.Web.Mvc" }) -ne $null

    # The filters folder.
    $FiltersProjectItem = $project.ProjectItems.Item("Filters");

    if ($IsVbProject) {
        # For VB project, delete TokenHelper.cs, SharePointContext.cs and SharePointContextFilterAttribute.cs
        $project.ProjectItems | Where-Object { ($_.Name -eq "TokenHelper.cs") -or ($_.Name -eq "SharePointContext.cs") } | ForEach-Object { $_.Delete() }
        $FiltersProjectItem.ProjectItems | Where-Object { ($_.Name -eq "SharePointContextFilterAttribute.cs") } | ForEach-Object { $_.Delete() }

        # Delete SharePointContextFilterAttribute.vb if the web project is not MVC.
        if (!$IsMvcProject) {
            $FiltersProjectItem.ProjectItems | Where-Object { $_.Name -eq "SharePointContextFilterAttribute.vb" } | ForEach-Object { $_.Delete() }
        }

        # Add Imports for VB project
        $VbImports | ForEach-Object {
            if (!($project.Object.Imports -contains $_)) {
                $project.Object.Imports.Add($_)
            }
        }
    }
    else {
        # For CSharp project, delete TokenHelper.vb, SharePointContext.vb and SharePointContextFilterAttribute.vb
        $project.ProjectItems | Where-Object { ($_.Name -eq "TokenHelper.vb") -or ($_.Name -eq "SharePointContext.vb") } | ForEach-Object { $_.Delete() }
        $FiltersProjectItem.ProjectItems | Where-Object { ($_.Name -eq "SharePointContextFilterAttribute.vb") } | ForEach-Object { $_.Delete() }

        # Delete SharePointContextFilterAttribute.cs if the web project is not MVC.
        if (!$IsMvcProject) {
            $FiltersProjectItem.ProjectItems | Where-Object { $_.Name -eq "SharePointContextFilterAttribute.cs" } | ForEach-Object { $_.Delete() }
        }
    }
    
    # Delete the Filters folder if there is no item in it.
    if ($FiltersProjectItem.ProjectItems.Count -eq 0) {
        try {
            $FiltersProjectItem.Delete()
        }
        catch {
            Write-Host "Error while deleting the Filters folder: " + $_.Exception -ForegroundColor Yellow
        }
    }

    # Set CopyLocal = True as needed
    Foreach ($spRef in $CopyLocalReferences) {
        $project.Object.References | Where-Object { $_.Identity -eq $spRef } | ForEach-Object { $_.CopyLocal = $True }
    }

} catch {

    Write-Host "Error while installing package: " + $_.Exception -ForegroundColor Red
    exit
}
# SIG # Begin signature block
# MIIiPAYJKoZIhvcNAQcCoIIiLTCCIikCAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCBQfEY+NGRkMyCV
# ClOJCX1xVSqPM9I7jehM9+Wmk6pRw6CCC4QwggUMMIID9KADAgECAhMzAAABT+fG
# YslG9Kl/AAAAAAFPMA0GCSqGSIb3DQEBCwUAMH4xCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNpZ25p
# bmcgUENBIDIwMTAwHhcNMTYxMTE3MjE1OTE0WhcNMTgwMjE3MjE1OTE0WjCBgzEL
# MAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1v
# bmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9Q
# UjEeMBwGA1UEAxMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMIIBIjANBgkqhkiG9w0B
# AQEFAAOCAQ8AMIIBCgKCAQEAtImQinYMrMU9obyB6NdQCLtaaaeux8y4W704DyFR
# Rggj0b0imXO3KO/3B6sr+Uj3pRQFqU0kG21hlpyDnTPALHmZ8F3z7NVE36XNWfp2
# rQY/xkoD5uotlBDCZm/9YtBQitEikSOXZTShxJoCXpLiuHwoeMJe40b3yu84V4is
# VgZYypgbx6jXXjaumkUw47a3PRjCpyeweU1T2DLmdqNQKvY/urtBHiSGTZibep72
# LOK8kGBl+5Zp+uATaOKJKi51GJ3Cbbgh9JleKn8xoKcNzO9PEW7+SUJOYd43yyue
# QO/Oq15wCHOlcnu3Rs5bMlNdijlRb7DXqHjdoyhvXu5CHwIDAQABo4IBezCCAXcw
# HwYDVR0lBBgwFgYKKwYBBAGCNz0GAQYIKwYBBQUHAwMwHQYDVR0OBBYEFJIOoRFx
# ti9VDcMP9MlcdC5aDGq/MFIGA1UdEQRLMEmkRzBFMQ0wCwYDVQQLEwRNT1BSMTQw
# MgYDVQQFEysyMzA4NjUrYjRiMTI4NzgtZTI5My00M2U5LWIyMWUtN2QzMDcxOWQ0
# NTJmMB8GA1UdIwQYMBaAFOb8X3u7IgBY5HJOtfQhdCMy5u+sMFYGA1UdHwRPME0w
# S6BJoEeGRWh0dHA6Ly9jcmwubWljcm9zb2Z0LmNvbS9wa2kvY3JsL3Byb2R1Y3Rz
# L01pY0NvZFNpZ1BDQV8yMDEwLTA3LTA2LmNybDBaBggrBgEFBQcBAQROMEwwSgYI
# KwYBBQUHMAKGPmh0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2kvY2VydHMvTWlj
# Q29kU2lnUENBXzIwMTAtMDctMDYuY3J0MAwGA1UdEwEB/wQCMAAwDQYJKoZIhvcN
# AQELBQADggEBABHAuWpDNf6FsTiADbh0dSyNcUm4PEHtLb3iBjaQdiuJ5baB6Ybj
# GIyWkzJCp6f2tzQlOdDGekPq23dwzNTpQuuoxVUCdXie2BC+BxvKlGP7PA9x7tRV
# Z9cp9mq/B7zlj4Lq+KHiczM/FJJeobplVzdFhYBc1izGizxqh6MHEcvs2XE4IDUk
# PVS9zFWJ9HcQm+WZqg+uxjyOn9oAT8994bPAIPdSMfciSNVhjX8mAhl9g8xhkyrd
# uNziCLOn3+EEd2DI9Kw1yzHlbHVRxTd7E2pOlWuPQJ7ITT6uvVnFINbCeK23ZFs7
# 0MAVcDQU5cWephzH9P/2y0jB4o3zbs6qtKAwggZwMIIEWKADAgECAgphDFJMAAAA
# AAADMA0GCSqGSIb3DQEBCwUAMIGIMQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2Fz
# aGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENv
# cnBvcmF0aW9uMTIwMAYDVQQDEylNaWNyb3NvZnQgUm9vdCBDZXJ0aWZpY2F0ZSBB
# dXRob3JpdHkgMjAxMDAeFw0xMDA3MDYyMDQwMTdaFw0yNTA3MDYyMDUwMTdaMH4x
# CzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRt
# b25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01p
# Y3Jvc29mdCBDb2RlIFNpZ25pbmcgUENBIDIwMTAwggEiMA0GCSqGSIb3DQEBAQUA
# A4IBDwAwggEKAoIBAQDpDmRQeWe1xOP9CQBMnpSs91Zo6kTYz8VYT6mldnxtRbrT
# OZK0pB75+WWC5BfSj/1EnAjoZZPOLFWEv30I4y4rqEErGLeiS25JTGsVB97R0sKJ
# HnGUzbV/S7SvCNjMiNZrF5Q6k84mP+zm/jSYV9UdXUn2siou1YW7WT/4kLQrg3TK
# K7M7RuPwRknBF2ZUyRy9HcRVYldy+Ge5JSA03l2mpZVeqyiAzdWynuUDtWPTshTI
# wciKJgpZfwfs/w7tgBI1TBKmvlJb9aba4IsLSHfWhUfVELnG6Krui2otBVxgxrQq
# W5wjHF9F4xoUHm83yxkzgGqJTaNqZmN4k9Uwz5UfAgMBAAGjggHjMIIB3zAQBgkr
# BgEEAYI3FQEEAwIBADAdBgNVHQ4EFgQU5vxfe7siAFjkck619CF0IzLm76wwGQYJ
# KwYBBAGCNxQCBAweCgBTAHUAYgBDAEEwCwYDVR0PBAQDAgGGMA8GA1UdEwEB/wQF
# MAMBAf8wHwYDVR0jBBgwFoAU1fZWy4/oolxiaNE9lJBb186aGMQwVgYDVR0fBE8w
# TTBLoEmgR4ZFaHR0cDovL2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVj
# dHMvTWljUm9vQ2VyQXV0XzIwMTAtMDYtMjMuY3JsMFoGCCsGAQUFBwEBBE4wTDBK
# BggrBgEFBQcwAoY+aHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9N
# aWNSb29DZXJBdXRfMjAxMC0wNi0yMy5jcnQwgZ0GA1UdIASBlTCBkjCBjwYJKwYB
# BAGCNy4DMIGBMD0GCCsGAQUFBwIBFjFodHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20v
# UEtJL2RvY3MvQ1BTL2RlZmF1bHQuaHRtMEAGCCsGAQUFBwICMDQeMiAdAEwAZQBn
# AGEAbABfAFAAbwBsAGkAYwB5AF8AUwB0AGEAdABlAG0AZQBuAHQALiAdMA0GCSqG
# SIb3DQEBCwUAA4ICAQAadO9XTyl7xBaFeLhQ0yL8CZ2sgpf4NP8qLJeVEuXkv8+/
# k8jjNKnbgbjcHgC+0jVvr+V/eZV35QLU8evYzU4eG2GiwlojGvCMqGJRRWcI4z88
# HpP4MIUXyDlAptcOsyEp5aWhaYwik8x0mOehR0PyU6zADzBpf/7SJSBtb2HT3wfV
# 2XIALGmGdj1R26Y5SMk3YW0H3VMZy6fWYcK/4oOrD+Brm5XWfShRsIlKUaSabMi3
# H0oaDmmp19zBftFJcKq2rbtyR2MX+qbWoqaG7KgQRJtjtrJpiQbHRoZ6GD/oxR0h
# 1Xv5AiMtxUHLvx1MyBbvsZx//CJLSYpuFeOmf3Zb0VN5kYWd1dLbPXM18zyuVLJS
# R2rAqhOV0o4R2plnXjKM+zeF0dx1hZyHxlpXhcK/3Q2PjJst67TuzyfTtV5p+qQW
# BAGnJGdzz01Ptt4FVpd69+lSTfR3BU+FxtgL8Y7tQgnRDXbjI1Z4IiY2vsqxjG6q
# HeSF2kczYo+kyZEzX3EeQK+YZcki6EIhJYocLWDZN4lBiSoWD9dhPJRoYFLv1keZ
# oIBA7hWBdz6c4FMYGlAdOJWbHmYzEyc5F3iHNs5Ow1+y9T1HU7bg5dsLYT0q15Is
# zjdaPkBCMaQfEAjCVpy/JF1RAp1qedIX09rBlI4HeyVxRKsGaubUxt8jmpZ1xTGC
# Fg4wghYKAgEBMIGVMH4xCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9u
# MRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRp
# b24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNpZ25pbmcgUENBIDIwMTACEzMA
# AAFP58ZiyUb0qX8AAAAAAU8wDQYJYIZIAWUDBAIBBQCggfkwGQYJKoZIhvcNAQkD
# MQwGCisGAQQBgjcCAQQwHAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwLwYJ
# KoZIhvcNAQkEMSIEIA3CMSrWZFMuOIH2UaE5kHIJnsIqkEQ8ofONu8U6IMmRMIGM
# BgorBgEEAYI3AgEMMX4wfKBigGAAaQBuAHMAdABhAGwAbABfADAAOQA4ADcANABi
# AGYAYQAtAGIAMgA5ADkALQA0AGEANQAyAC0AOQAzAGEAYQAtADAAMgAyADUAOABk
# AGYAYgA0AGUAMgA3AC4AcABzADGhFoAUaHR0cDovL21pY3Jvc29mdC5jb20wDQYJ
# KoZIhvcNAQEBBQAEggEAS3++CVPvzfb+e3AjqjNltKdFLD94O8k0c9hOA9B3W5Jk
# YgPPiJTqKvSSs44T5QH1h0I4tjBWLDf/Oyh2QRaISAf3hT66W30l8vLdRtfirzPC
# o3EmXN+8Yx4g+XobobcwaOO1PO6G6Nm7ZX6fvVMUO1g8TI4+v2h2gRHxXISwcuKB
# VOaQkFoSEEtXtREsPJFk9dNxhwm7AYBATq8I8hPMk+chk0TMF7Pv5xVT3ocsP6Fe
# iRCYoqkp313ZeJn+yTzbx1yfGWj+EMM3f9JtJ6wh45eCCe1H3Znh/lBRn1wBlJV5
# HoIh5UnVBAQ+VV2iJAXGxkpo/okW23UwW06knupRS6GCE00wghNJBgorBgEEAYI3
# AwMBMYITOTCCEzUGCSqGSIb3DQEHAqCCEyYwghMiAgEDMQ8wDQYJYIZIAWUDBAIB
# BQAwggE9BgsqhkiG9w0BCRABBKCCASwEggEoMIIBJAIBAQYKKwYBBAGEWQoDATAx
# MA0GCWCGSAFlAwQCAQUABCCTm+3PGYWkbdRA9EVmCfvBAhBqhNQ57LCt4RDr6AD/
# nQIGWZI4IV0yGBMyMDE3MDgxODE3MjQ1My44NjlaMAcCAQGAAgH0oIG5pIG2MIGz
# MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVk
# bW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMQ0wCwYDVQQLEwRN
# T1BSMScwJQYDVQQLEx5uQ2lwaGVyIERTRSBFU046N0QyRS0zNzgyLUIwRjcxJTAj
# BgNVBAMTHE1pY3Jvc29mdCBUaW1lLVN0YW1wIFNlcnZpY2Wggg7QMIIGcTCCBFmg
# AwIBAgIKYQmBKgAAAAAAAjANBgkqhkiG9w0BAQsFADCBiDELMAkGA1UEBhMCVVMx
# EzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoT
# FU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEyMDAGA1UEAxMpTWljcm9zb2Z0IFJvb3Qg
# Q2VydGlmaWNhdGUgQXV0aG9yaXR5IDIwMTAwHhcNMTAwNzAxMjEzNjU1WhcNMjUw
# NzAxMjE0NjU1WjB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQ
# MA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9u
# MSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMDCCASIwDQYJ
# KoZIhvcNAQEBBQADggEPADCCAQoCggEBAKkdDbx3EYo6IOz8E5f1+n9plGt0VBDV
# pQoAgoX77XxoSyxfxcPlYcJ2tz5mK1vwFVMnBDEfQRsalR3OCROOfGEwWbEwRA/x
# YIiEVEMM1024OAizQt2TrNZzMFcmgqNFDdDq9UeBzb8kYDJYYEbyWEeGMoQedGFn
# kV+BVLHPk0ySwcSmXdFhE24oxhr5hoC732H8RsEnHSRnEnIaIYqvS2SJUGKxXf13
# Hz3wV3WsvYpCTUBR0Q+cBj5nf/VmwAOWRH7v0Ev9buWayrGo8noqCjHw2k4GkbaI
# CDXoeByw6ZnNPOcvRLqn9NxkvaQBwSAJk3jN/LzAyURdXhacAQVPIk0CAwEAAaOC
# AeYwggHiMBAGCSsGAQQBgjcVAQQDAgEAMB0GA1UdDgQWBBTVYzpcijGQ80N7fEYb
# xTNoWoVtVTAZBgkrBgEEAYI3FAIEDB4KAFMAdQBiAEMAQTALBgNVHQ8EBAMCAYYw
# DwYDVR0TAQH/BAUwAwEB/zAfBgNVHSMEGDAWgBTV9lbLj+iiXGJo0T2UkFvXzpoY
# xDBWBgNVHR8ETzBNMEugSaBHhkVodHRwOi8vY3JsLm1pY3Jvc29mdC5jb20vcGtp
# L2NybC9wcm9kdWN0cy9NaWNSb29DZXJBdXRfMjAxMC0wNi0yMy5jcmwwWgYIKwYB
# BQUHAQEETjBMMEoGCCsGAQUFBzAChj5odHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20v
# cGtpL2NlcnRzL01pY1Jvb0NlckF1dF8yMDEwLTA2LTIzLmNydDCBoAYDVR0gAQH/
# BIGVMIGSMIGPBgkrBgEEAYI3LgMwgYEwPQYIKwYBBQUHAgEWMWh0dHA6Ly93d3cu
# bWljcm9zb2Z0LmNvbS9QS0kvZG9jcy9DUFMvZGVmYXVsdC5odG0wQAYIKwYBBQUH
# AgIwNB4yIB0ATABlAGcAYQBsAF8AUABvAGwAaQBjAHkAXwBTAHQAYQB0AGUAbQBl
# AG4AdAAuIB0wDQYJKoZIhvcNAQELBQADggIBAAfmiFEN4sbgmD+BcQM9naOhIW+z
# 66bM9TG+zwXiqf76V20ZMLPCxWbJat/15/B4vceoniXj+bzta1RXCCtRgkQS+7lT
# jMz0YBKKdsxAQEGb3FwX/1z5Xhc1mCRWS3TvQhDIr79/xn/yN31aPxzymXlKkVIA
# rzgPF/UveYFl2am1a+THzvbKegBvSzBEJCI8z+0DpZaPWSm8tv0E4XCfMkon/VWv
# L/625Y4zu2JfmttXQOnxzplmkIz/amJ/3cVKC5Em4jnsGUpxY517IW3DnKOiPPp/
# fZZqkHimbdLhnPkd/DjYlPTGpQqWhqS9nhquBEKDuLWAmyI4ILUl5WTs9/S/fmNZ
# JQ96LjlXdqJxqgaKD4kWumGnEcua2A5HmoDF0M2n0O99g/DhO3EJ3110mCIIYdqw
# UB5vvfHhAN/nMQekkzr3ZUd46PioSKv33nJ+YWtvd6mBy6cJrDm77MbL2IK0cs0d
# 9LiFAR6A+xuJKlQ5slvayA1VmXqHczsI5pgt6o3gMy4SKfXAL1QnIffIrE7aKLix
# qduWsqdCosnPGUFN4Ib5KpqjEWYw07t0MkvfY3v1mYovG8chr1m1rtxEPJdQcdeh
# 0sVV42neV8HR3jDA/czmTfsNv11P6Z0eGTgvvM9YBS7vDaBQNdrvCScc1bN+NR4I
# uto229Nfj950iEkSMIIE2jCCA8KgAwIBAgITMwAAAKJMjh3aqSF8hAAAAAAAojAN
# BgkqhkiG9w0BAQsFADB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3Rv
# bjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0
# aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMDAeFw0x
# NjA5MDcxNzU2NDlaFw0xODA5MDcxNzU2NDlaMIGzMQswCQYDVQQGEwJVUzETMBEG
# A1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWlj
# cm9zb2Z0IENvcnBvcmF0aW9uMQ0wCwYDVQQLEwRNT1BSMScwJQYDVQQLEx5uQ2lw
# aGVyIERTRSBFU046N0QyRS0zNzgyLUIwRjcxJTAjBgNVBAMTHE1pY3Jvc29mdCBU
# aW1lLVN0YW1wIFNlcnZpY2UwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB
# AQCmAXcFe8N9DnZovcaog8aCewFwqLBqhHJPVI5tvmcgar7sLd0vR3Hhkv10Ymu+
# dNuFNts0yMdpCuY2EklAR7hBNFliPfETp64JASjRFFhjHzmwaDYE2FnaTVvgkXES
# /EGzDc7BcqEVJvbzmVvo4IquEHWqOdfxDvIJwTF1DCkqKd3sjjcq32uq4zK42E17
# yHEQkMG+OoYZC+jprR+4NCOtYYyWLvs+TC9CZcYLHrGwWMJrm+fPiwTHk0Gd5nm4
# 5feWV9yAxQUFAKZBIjcW+bTrR6wvOa3QxdMMRNcJW2nRCfMDK2MnWgeQ9O+MozMl
# jTcsPyWZs/MVPqaS6vlRGOXVAgMBAAGjggEbMIIBFzAdBgNVHQ4EFgQUbrvZwcLa
# FrB8rcJTf+fQFxM9vFcwHwYDVR0jBBgwFoAU1WM6XIoxkPNDe3xGG8UzaFqFbVUw
# VgYDVR0fBE8wTTBLoEmgR4ZFaHR0cDovL2NybC5taWNyb3NvZnQuY29tL3BraS9j
# cmwvcHJvZHVjdHMvTWljVGltU3RhUENBXzIwMTAtMDctMDEuY3JsMFoGCCsGAQUF
# BwEBBE4wTDBKBggrBgEFBQcwAoY+aHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3Br
# aS9jZXJ0cy9NaWNUaW1TdGFQQ0FfMjAxMC0wNy0wMS5jcnQwDAYDVR0TAQH/BAIw
# ADATBgNVHSUEDDAKBggrBgEFBQcDCDANBgkqhkiG9w0BAQsFAAOCAQEANZlXbTP2
# SJ2eQdzMqWDuXEdIVBEKhrlXP6dtmI7KfGmmapaDzjmyvWQOmTC7vtzgdYJrQinh
# hUSOMXtzaFl5mJ1XtBYH/KIpvKNwgiEmHWVLGeaJKlXNr7qSat7ImgkCWyUWl8er
# uVra9POgG4JwqkrGRrV6gMRiQoP3cVpkKyb9844jC04W8hvy0DUKQ9o886kakYrE
# NXjZEKhjBqNkf6y/KO6oHBV4j6D3wnHF2LiSzqqXcjlMD2hkRE7KhuUty7ICsSg9
# /Rm/ANZI098NtO0MJJBFFLyVeToD7GOGPDTucbI9Lmp5kIK26xsaWbuvi4t58an9
# SjHyPGobFV06xqGCA3kwggJhAgEBMIHjoYG5pIG2MIGzMQswCQYDVQQGEwJVUzET
# MBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMV
# TWljcm9zb2Z0IENvcnBvcmF0aW9uMQ0wCwYDVQQLEwRNT1BSMScwJQYDVQQLEx5u
# Q2lwaGVyIERTRSBFU046N0QyRS0zNzgyLUIwRjcxJTAjBgNVBAMTHE1pY3Jvc29m
# dCBUaW1lLVN0YW1wIFNlcnZpY2WiJQoBATAJBgUrDgMCGgUAAxUAXi8X6XGE0jLL
# 7NdeSjv4TreH6fWggcIwgb+kgbwwgbkxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpX
# YXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQg
# Q29ycG9yYXRpb24xDTALBgNVBAsTBE1PUFIxJzAlBgNVBAsTHm5DaXBoZXIgTlRT
# IEVTTjo1N0Y2LUMxRTAtNTU0QzErMCkGA1UEAxMiTWljcm9zb2Z0IFRpbWUgU291
# cmNlIE1hc3RlciBDbG9jazANBgkqhkiG9w0BAQUFAAIFAN1BW90wIhgPMjAxNzA4
# MTgxMjI4MTNaGA8yMDE3MDgxOTEyMjgxM1owdzA9BgorBgEEAYRZCgQBMS8wLTAK
# AgUA3UFb3QIBADAKAgEAAgIHkAIB/zAHAgEAAgIYKDAKAgUA3UKtXQIBADA2Bgor
# BgEEAYRZCgQCMSgwJjAMBgorBgEEAYRZCgMBoAowCAIBAAIDFuNgoQowCAIBAAID
# B6EgMA0GCSqGSIb3DQEBBQUAA4IBAQBh2IpEmrIua7Cbb2w10lWrQK8MSstUKqmr
# UiashOwWxrfT7GCoJ6w2xmK1GmEF5MKR+yIJg2hfbCEALsAca390hFjvJBxZKGjS
# ee2YGb+3VkQqsKPWY6XCzydPyA0sGSoP8gH1VN+JEGT/v1Zag7XNyldNjbbDfzI9
# rTOZH45RN6I4qbVP7tu1GtLOL8fGSLSvTSPqKgvPGn4k6/iO0k1ocpcusgdX7mV3
# BzJ6KBEZ4fgP2AEdbScAhIyBKZIqZ/e7so6LFas3Ob/EipsZGLevxb+H0MR2k6+j
# 7T/U4e6VVZNeSwki0uj4/Iu/tjNIzhIJJz3FS0cy+Z6MqxhhdE6DMYIC9TCCAvEC
# AQEwgZMwfDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNV
# BAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEmMCQG
# A1UEAxMdTWljcm9zb2Z0IFRpbWUtU3RhbXAgUENBIDIwMTACEzMAAACiTI4d2qkh
# fIQAAAAAAKIwDQYJYIZIAWUDBAIBBQCgggEyMBoGCSqGSIb3DQEJAzENBgsqhkiG
# 9w0BCRABBDAvBgkqhkiG9w0BCQQxIgQgCDzv0nnqDx0HfktgvUIreIjXYxZh2uBR
# 5yRxhhAH0RswgeIGCyqGSIb3DQEJEAIMMYHSMIHPMIHMMIGxBBReLxfpcYTSMsvs
# 115KO/hOt4fp9TCBmDCBgKR+MHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNo
# aW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29y
# cG9yYXRpb24xJjAkBgNVBAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEw
# AhMzAAAAokyOHdqpIXyEAAAAAACiMBYEFI9sKXWA20a/CeDmoivvK2938wqnMA0G
# CSqGSIb3DQEBCwUABIIBAFe9JCmCX5K1MuORUVpw+uEoiIBFAIIKHXJS5FA3NHZ5
# pcqkGI5L5h+J0DKt2vbWsfa9RVKqIDY/KWWBuaJw9OHYxXSr4XNwVjKnkX+jNCm6
# F83pijF/DiUEaVTmVDXARmLvoRI2EwG2cba5r3d+qqz28hY3ax7kPKVgMuAtKOBW
# 8k8R8h2WhDavjEbVJMx04g3azG2uoxg6KbVyZIoWKLdgfU9HgFku3SsklO30p7E1
# Fm9jCiqqK/J7enIpTMPzuuDDNYgM/B3UytnKTTWnKCkBVthrq28O3UoIfNnYkEAo
# hskAjM7MOD9vjzEJhCqGEQhsMMStOSl6lJ7/wTvfQng=
# SIG # End signature block
