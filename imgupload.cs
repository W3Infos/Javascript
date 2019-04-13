 Practice prc = (from x in _context.Practices.Where(x => x.PracticeId.Equals(prctSearch.PracticeId)) select x).FirstOrDefault();
            string currentImg = string.Empty;

            if (prc.Logo != null)
            {
                if (prc.Logo.Contains("/png"))
                {
                    prc.Logo = prc.Logo.Replace("data:image/png;base64,", string.Empty);
                    currentImg = "data:image/png;base64,";
                }

                if (prc.Logo.Contains("/jpeg"))
                {
                    prc.Logo = prc.Logo.Replace("data:image/jpeg;base64,", string.Empty);
                    currentImg = "data:image/jpeg;base64,";
                }

                prc.Logo = prc.Logo.Replace('-', '+').Replace('_', '/').PadRight(4 * ((prc.Logo.Length + 3) / 4), '=');

                byte[] imageBytes = Convert.FromBase64String(prc.Logo);

                prc.Logo = currentImg + Convert.ToBase64String(imageBytes);
            }
